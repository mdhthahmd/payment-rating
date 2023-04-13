<template>
    <main class="mx-auto flex w-full max-w-7xl flex-grow flex-col px-6 lg:px-8">
        <div class="my-auto flex-shrink-0 py-16 sm:py-32">
            <p class="text-base font-semibold text-red-600">404</p>
            <h1 class="mt-2 text-4xl font-bold tracking-tight text-gray-900 sm:text-5xl">Page not found</h1>
            <p class="mt-2 text-base text-gray-500">Sorry, we couldn’t find the page you’re looking for.</p>
            <div class="mt-6">
                <RouterLink to="/" class="text-base font-medium text-red-600 hover:text-red-500">
                    Go back home
                    <span aria-hidden="true"> &rarr;</span>
                </RouterLink>
            </div>
        </div>
    </main>
</template>