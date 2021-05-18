import Vue from 'vue'
import Vuex from 'vuex'

//services 


Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        user: {
            isLogin: true
        }
    },
    getters: {
        auth(state) {
            return state.user
        }
    },
    mutations: {},
    actions: {}
})