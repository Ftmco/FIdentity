import Vue from 'vue'
import App from './App.vue'
import Vuesax from 'vuesax'
import router from './router/index'
import store from './store'

import 'vuesax/dist/vuesax.css'
import 'vue-awesome/icons/flag'
import 'vue-awesome/icons'
import 'vue-awesome/dist/vue-awesome'

import VueMeta from 'vue-meta'
Vue.use(VueMeta)
Vue.use(Vuesax)

Vue.config.productionTip = false

new Vue({
    router,
    store,
    render: h => h(App),
}).$mount('#app')
