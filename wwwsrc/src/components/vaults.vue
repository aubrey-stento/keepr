<template>
  <div class="row">
    <div class="col-12">


    </div>
    <div v-for="vault in vaults" @click="setActiveVault(vault)" class="col-4" :key="vault._id">
      <div class="card">
        <router-link :to="{name: 'vault', params: {vaultId: vault.id}}">
          <h1 class="card-title">{{vault.name}}</h1>
        </router-link>
        <button @click="deleteVault(vault)">DELETE</button>
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

      },
      deleteVault(vault) {
        this.$store.dispatch('deleteVault', vault)
      }
    }
  }

</script>

<style>


</style>