import fs from "fs";
import vue from "@vitejs/plugin-vue";
import path from "path";
import { execSync } from "child_process";
import { defineConfig } from "vite";
import { fileURLToPath, URL } from 'node:url';

export default defineConfig({
  base: '/payment-rating',
  plugins: [vue()],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
  server: {
    strictPort: true,
    https: generateCerts(),
    proxy: {
      "/payment-rating/api/": {
        changeOrigin: true,
        secure: false,
        rewrite: (path) => path.replace(/^\/payment-rating/, ''),
        target: process.env.ASPNETCORE_HTTPS_PORT
          ? `https://localhost:${process.env.ASPNETCORE_HTTPS_PORT}`
          : process.env.ASPNETCORE_URLS
            ? process.env.ASPNETCORE_URLS.split(";")[0]
            : "http://localhost:40457",
      },
    },
  },
});

function generateCerts() {
  const baseFolder =
    process.env.APPDATA !== undefined && process.env.APPDATA !== ""
      ? `${process.env.APPDATA}/ASP.NET/https`
      : `${process.env.HOME}/.aspnet/https`;
  const certificateArg = process.argv
    .map((arg) => arg.match(/--name=(?<value>.+)/i))
    .filter(Boolean)[0];
  const certificateName = certificateArg
    ? certificateArg.groups.value
    : process.env.npm_package_name;

  if (!certificateName) {
    console.error(
      "Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly."
    );
    process.exit(-1);
  }

  const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
  const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

  if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
    const outp = execSync(
      "dotnet " +
      [
        "dev-certs",
        "https",
        "--export-path",
        certFilePath,
        "--format",
        "Pem",
        "--no-password",
      ].join(" ")
    );
    console.log(outp.toString());
  }

  return {
    cert: fs.readFileSync(certFilePath, "utf8"),
    key: fs.readFileSync(keyFilePath, "utf8"),
  };
}

// import { defineConfig } from 'vite'
// import vue from '@vitejs/plugin-vue'
// import { fileURLToPath, URL } from 'node:url';

// // https://vitejs.dev/config/
// export default defineConfig({
//   plugins: [vue()],
//   resolve: {
//     alias: {
//       '@': fileURLToPath(new URL('./src', import.meta.url))
//     }
//   },
// })
