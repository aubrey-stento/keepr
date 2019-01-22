<template>
    <div class="vaultForm">
        <form @submit.prevent="createVault">
            <div class="form-group">
                <input class="form-control" type="text" placeholder="Name" v-model="formData.name">
                <input class="form-control" type="text" placeholder="Description" v-model="formData.description">
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
                formData: {
                    name: '',
                    description: ''
                }
            }
        },
        computed: {
            // vaults() {
            //     return this.$store.state.vaults
            // },
            user() {
                return this.$store.state.user
            },
            methods: {
                createVault() {
                    this.formData.creatorName = this.user.name
                    // this.formData.vaultName = this.vault.name
                    this.$store.dispatch('createVault', this.formData)
                    this.formData = {
                        name: '',
                        description: ''
                    }

                }
            }
        }
    }

</script>

<style>


</style>