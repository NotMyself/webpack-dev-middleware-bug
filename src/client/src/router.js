import Vue from "vue";
import Router from "vue-router";

import HelloWorld from "@/components/HelloWorld.vue";
import DeepLink from "@/components/DeepLink.vue";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      name: "HelloWorld",
      component: HelloWorld
    },
    {
      path: "/deep/link",
      name: "DeepLink",
      component: DeepLink
    }
  ]
});
