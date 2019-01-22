<template>
  <div class="row">
    <div v-for="vault in vaults" @click="setActiveVault(vault)" class="col-3" :key="vault._id">
      <div class="card">
        <router-link :to="{name: vault, params: {vaultId: vault._id}}">
          <h1 class="card-title">{{vault.name}}</h1>
        </router-link>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: 'Vaults',
    data() {
      return {

      }
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    mounted() {
      this.$store.dispatch('getVaults', this.user.id)
    },
    methods: {
      setActiveVault(vault) {
        this.$store.commit('setActiveVault', vault)
      }
    }
  }

</script>

<style>


</style>