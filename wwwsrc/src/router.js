import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
import Keep from './views/Keep.vue'
import userDash from './views/UserDash.vue'
import vault from './views/Vault.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      props: true
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      props: true,
      path: '/keep/:keepId',
      component: Keep,
      name: 'keep'
    },
    {
      path: '/userDash/',
      name: 'userDash',
      component: userDash
    },
    {
      path: '/vaults/:vaultId',
      name: 'vault',
      component: vault,
      props: true

    },
    {
      path: "*",
      redirect: '/'
    }
  ]
})
