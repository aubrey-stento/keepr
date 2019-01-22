<template>
    <div class="vaultForm">
        <form @submit.prevent="createVault">
            <div class="form-group">
                <input class="form-control" type="text" placeholder="Name" v-model="vaultData.name">
                <input class="form-control" type="text" placeholder="Description" v-model="vaultData.description">
                <button type="submit" class="btn btn-sm btn-info">Create Vault</button>
            </div>
        </form>

    </div>
</template>

<script>
    export default {
        name: 'VaultForm',
        data() {
            return {
                vaultData: {
                    name: '',
                    description: ''
                }
            }
        },
        computed: {
            vaults() {
                return this.$store.state.vaults
            },
            user() {
                return this.$store.state.user
            }
        },
        methods: {

            createVault() {
                debugger
                this.$store.dispatch('createVault', this.vaultData)

            }
        }

    }

</script>

<style>


</style>