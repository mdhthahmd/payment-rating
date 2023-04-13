import { createRouter, createWebHistory } from "vue-router";
import DashboardView from "@/views/DashboardView.vue";
import EmployersView from "@/views/EmployersView.vue";
import PaymentsView from "@/views/PaymentsView.vue";
import PendingView from "@/views/PendingView.vue"
import PageNotFoundView from "@/views/PageNotFoundView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "dashboard",
      component: DashboardView,
    },
    {
        path: "/employers",
        name: "employers",
        component: EmployersView,
    },
    {
      path: "/payments",
      name: "payments",
      component: PaymentsView,
    },
    {
      path: "/pending",
      name: "pending",
      component: PendingView,
    },
    {
      path: "/:pathMatch(.*)*",
      name: "not-found",
      component: PageNotFoundView,
  },
  ],
});

export default router;