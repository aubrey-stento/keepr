<template>
    <div class="keep container">
        <div class="row">
            <div class="col-8 card">
                <p>Name: {{keep.name}}</p>
                <p>Description: {{keep.description}}</p>
                <img :src="keep.image">
                <p class="textSpace"> <i class="far fa-eye"></i> {{keep.views}}</p>
                <p class="textSpace"> <i class="fas fa-share"></i> {{keep.shares}}</p>
                <p class="textSpace"> <i class="fab fa-kaggle"></i> {{keep.keeps}}</p>

            </div>
            <VaultForm></VaultForm>
        </div>
    </div>
</template>
<script>
    import VaultForm from "@/components/createVault.vue";
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
        },
        computed: {
            keep() {
                return this.$store.state.activeKeep || ''
            },
            user() {
                return this.$store.state.user
            }
        },
        methods: {
            updateKeep() {
                this.$store.dispatch('updateKeep', this.keepData)
            }
        },
        components: {
            VaultForm
        }
    }
</script>