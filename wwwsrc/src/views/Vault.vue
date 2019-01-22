<template>
    <div class="container-fluid">
        <div class="card-columns-count">
            <div v-for="keep in activeVault.keeps">
                {{keep}}
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Vault',
        data() {
            return {

            }
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            activeVault() {
                return this.$store.state.activeVault
            },
            vault() {
                return this.$store.state.vault
            }
        },
        methods: {},
        mounted() {
            this.$store.dispatch('getKeepsByVaultId', this.vaultId)
        },
        props: ["vaultId"]
    }

</script>

<style>


</style>