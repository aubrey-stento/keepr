<template>
    <div class="userDash">



        <VaultForm></VaultForm>
        <Vaults></Vaults>
        <KeepForm></KeepForm>
        <Keeps></Keeps>

    </div>
</template>

<script>
    import VaultForm from "@/components/createVault.vue";
    import Vaults from "@/components/vaults.vue";
    import KeepForm from "@/components/createKeep.vue";
    import Keeps from "@/components/keeps.vue";

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
            Vaults,
            KeepForm,
            Keeps
        }
    }

</script>

<style>


</style>