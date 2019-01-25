<template>
    <div class="keep container">
        <div class="row d-flex justify-content-center">
            <div class="col-8 card ">
                <img class="imgSize" :src='keep.img' height="400px">
                <p>Name: {{keep.name}}</p>
                <p>Description: {{keep.description}}</p>
                <img :src="keep.image">
                <p class="textSpace"> <i class="far fa-eye"></i> {{keep.views}}</p>
                <!-- <p class="textSpace"> <i class="fas fa-share"></i> {{keep.shares}}</p> -->
                <p class="textSpace"> <i class="fab fa-kaggle"></i> {{keep.keeps}}</p>
                <div v-if="user.id" class="dropdown">
                    <button class="btn btn-sm dropdown-toggle icon" type="button" id="dropdownMenuButton" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false"><i class="fab fa-kaggle"> </i>
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <p class="dropdown-item action" v-for="vault in vaults" @click="addToVault(vault.id, keep, user)"
                            :vaultData="vault" v-bind:value="vault.id">{{vault.name}}</p>
                    </div>
                </div>

            </div>

        </div>
    </div>
</template>
<script>

    export default {
        name: 'keep',
        props: ['keepId'],
        data() {
            return {
                keepData: {}
            }
        },
        mounted() {
            this.$store.dispatch("getKeepById", this.$route.params.keepId)
            let keep = this.$store.state.keeps.find(k => k.id == this.$route.params.keepId)
            keep.views++
            this.$store.dispatch("updateKeep", keep)
        },
        computed: {
            keep() {
                return this.$store.state.activeKeep || ''
            },
            user() {
                return this.$store.state.user
            },
            vaults() {
                return this.$store.state.vaults
            }
        },
        methods: {
            updateKeep() {
                this.$store.dispatch('updateKeep', this.keepData)
            },
            addToVault(vaultId, keep, user) {
                let payload = {
                    keepId: keep.id,
                    vaultId: vaultId,
                    userId: user.id
                }
                keep.keeps++
                this.$store.dispatch("updateKeep", keep)
                this.$store.dispatch('addToVault', payload)
            },
        },
        components: {

        }
    }
</script>