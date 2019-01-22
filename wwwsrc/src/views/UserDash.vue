<template>
    <div class="userDash">



        <VaultForm></VaultForm>
        <Vaults></Vaults>

    </div>
</template>

<script>
    import VaultForm from "@/components/createVault.vue";
    import Vaults from "@/components/vaults.vue"
    export default {
        name: 'userDash',
        data() {
            return {

            }
        },
        computed: {
            user() {
                return this.$store.state.user
            }
        },
        methods: {},
        components: {
            VaultForm,
            Vaults
        }
    }

</script>

<style>


</style>