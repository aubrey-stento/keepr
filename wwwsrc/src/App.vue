<template>
  <div id="app">
    <div id="nav">
      <nav class="navbar navbar-expand-sm navbar-muted bg-light navColor">
        <a class="navbar-brand fab fa-kaggle" href="#/">eepr</a>
        <a class="navbar-brand" v-if="user.id" href="#/userDash">UserDash</a>
        <div class="auth">
          <a type="button" class="btn btn-default navbar-btn " href="#/login" v-if="!user.id">Sign
            in/Register</a>
          <button type="button" class="btn btn-default navbar-btn" v-else="user.id" @click="logout">Logout</button>

        </div>
      </nav>
    </div>
    <router-view />
  </div>
</template>

<script>
  export default {
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout")
      }
    },
    mounted() {
      //checks for valid session
      this.$store.dispatch("authenticate");
    },
  }
</script>

<style scoped>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  .auth {
    display: flex;
    justify-content: right
  }
</style>