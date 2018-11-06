import Vue from 'vue'
import Router from 'vue-router'
import MainPage from '@/components/MainPage'
import axios from 'axios'

Vue.use(Router)
Vue.prototype.$axios = axios

export default new Router({
  routes: [
    {
      path: '/',
      name: 'MainPage',
      component: MainPage
    }
  ]
})
