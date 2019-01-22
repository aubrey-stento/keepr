<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12">
        <input type="text" v-model="search" class="form-control" placeholder="Search Keeps" />
        <li v-show="'search'.includes(filteredKeeps)"></li>
      </div>

    </div>

    <div class="row">
      <div class="card-columns count">
        <div v-for="keep in filteredKeeps">
          <div class="card">
            <router-link :to="{name: 'keep', params: {keepId: keep.id, keep: keep}}">
              <img class="imgSize" :src='keep.img'>
              <p class="textSpace">Name: {{keep.name}}</p>
              <p class="textSpace">Description: {{keep.description}}</p>
              <p class="textSpace"> <i class="far fa-eye"></i> {{keep.views}}</p>
              <p class="textSpace"> <i class="fas fa-share"></i> {{keep.shares}}</p>

            </router-link>
          </div>
        </div>

      </div>
    </div>

    <h1>Welcome Home</h1>
  </div>



</template>

<script>
  export default {
    name: "home",
    data() {
      return {
        search: ''
      }
    },
    mounted() {
      //blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }
      this.$store.dispatch("getAllPublicKeeps")
    },

    computed: {
      keeps() {
        return this.$store.state.keeps
      },
      filteredKeeps: function () {
        return this.keeps.filter((keep) => {
          return keep.name.toLowerCase().includes(this.search.toLowerCase())
        })
      },
      user() {
        return this.$store.state.user
      }
    },
    methods: {

    }
  };
</script>
<style>
  .count {
    column-count: 4;
  }
</style>