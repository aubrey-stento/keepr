<template>
    <div class="container-fluid">
        <div class="row">


            <div class="card-columns-count">
                <div v-for="keep in activeVault.keeps">
                    <div class="card">
                        <button @click="deleteVaultKeep(activeVault)">DELETE</button>
                        <img class="imgSize" :src='keep.img' height="250px">
                        <p class="textSpace">Name: {{keep.name}}</p>
                        <p class="textSpace">Description: {{keep.description}}</p>
                        <p class="textSpace"> <i class="far fa-eye"></i> {{keep.views}}</p>
                        <!-- <p class="textSpace"> <i class="fas fa-share"></i> {{keep.shares}}</p> -->
                        <p class="textSpace"> <i class="fab fa-kaggle"></i> {{keep.keeps}}</p>


                    </div>
                    <!-- {{keep}} -->
                </div>
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
            },
            vaultKeeps() {
                return this.$store.state.vaultKeeps
            }
        },
        methods: {
            deleteVaultKeep(vaultkeep) {
                debugger
                this.$store.dispatch('deleteVaultKeep', vaultkeep)
            }
        },
        mounted() {
            this.$store.dispatch('getKeepsByVaultId', this.vaultId)
        },
        props: ["vaultId"]
    }

</script>

<style>
    .count {
        column-count: 3;
    }
</style>