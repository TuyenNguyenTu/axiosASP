<template>
  <div id="app">
    <HelloWorld msg="Welcome to Your Vue.js App" />
    <div>
      <hr />
      <router-link to="/list-data">Home</router-link>||
      <router-link to="/contact">Contact</router-link>
      <hr />
    </div>

    <router-view></router-view>
  </div>
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";

export default {
  name: "App",
  components: {
    HelloWorld
  },
  data: function() {
    return {
      showNavigation: false
    };
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
