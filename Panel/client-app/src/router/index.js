import Vue from 'vue'
import Router from 'vue-router'

import Home from '../components/Main/Home.vue'

Vue.use(Router)

const router = new Router({
    routes: [
        {
            path: '/',
            name: 'Home',
            component: Home
        },
        {
            path: '/*',
            redirect:'/404'
        }
    ],
    mode: 'history'
})


export default router