import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    activeKeep: {},
    vaults: [],
    activeVault: {},
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    logout(state) {
      state.user = {}
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setActiveKeep(state, activeKeep) {
      state.activeKeep = activeKeep
    },
    setVault(state, vault) {
      state.vaults = vault
    },
    setActiveVault(state, activeVault) {
      state.activeVault = activeVault
    },
    setVaultKeep(state, vaultKeep) {
      state.vaultKeep = vaultKeep
    }
  },


  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit('logout')
          router.push({ name: 'home' })
        })
    },

    // KEEPS

    getAllPublicKeeps({ commit, dispatch }) {
      api.get('keeps/')
        .then(res => {
          console.log(res)
          commit('setKeeps', res.data)
        })
    },

    getKeepById({ commit, dispatch }, keepId) {

      api.get('keeps/' + keepId)
        .then(res => {
          console.log(res.data)
          commit('setActiveKeep', res.data)
          // dispatch('updateKeep')
        })
    },

    updateKeep({ commit, dispatch }, payload) {
      api.put('keeps/' + payload.id, payload)
        .then(res => {
          // commit('setKeeps', res.data)
          dispatch('getAllPublicKeeps')
        })
    },

    getKeepsByVaultId({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId)
        .then(res => {
          let vault = res.data
          api.get('vaultkeeps/' + vaultId)
            .then(res => {
              vault.keeps = res.data
              commit('setActiveVault', vault)

            })
        })

    },
    createKeep({ commit, dispatch }, keepData) {
      api.post('keeps/', keepData)
        .then(res => {
          console.log(res.data)
          commit('setKeeps', res.data)
          dispatch('getAllPublicKeeps', res.data)
        })
    },
    getKeepsByUserId({ commit, dispatch }, userId) {
      api.get('/keeps/user/' + userId)
        .then(res => {
          console.log(res.data)
          commit('setKeeps', res.data)
        })
    },
    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('/keeps/' + keepId)
        .then(res => {
          dispatch('getAllPublicKeeps')
        })
    },


    // VAULTS

    createVault({ commit, dispatch }, vaultData) {
      api.post('vaults', vaultData)
        .then(res => {
          console.log(res.data)
          commit('setVault', res.data)
          dispatch('getVaults', res.data)
        })
    },

    getVaults({ commit, dispatch }) {
      api.get('/vaults')
        .then(res => {
          console.log(res.data)
          commit('setVault', res.data)

        })
    },
    deleteVault({ commit, dispatch }, vault) {
      api.delete('/vaults/' + vault.id)
        .then(res => {
          dispatch('getVaults')
        })
    },


    // VAULTKEEPS

    addToVault({ commit, dispatch }, payload) {
      api.post('/vaultkeeps', payload)
        .then(res => {
          // payload.keepId.keep++
          console.log(res.data)
          commit('setVaultKeep', payload)
          dispatch('getKeepsByVaultId')
        })
    },

    // delete a keep from a vault
    deleteVaultKeep({ commit, dispatch }, payload) {
      api.delete('vaultkeeps/' + payload.vaultId + '/' + payload.keepId)
        .then(res => {
          dispatch("getKeepsByVaultId", payload.vaultId)
        })
    },
  }
})