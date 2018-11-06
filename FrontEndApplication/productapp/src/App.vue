<template>
  <div id="app">
    <div id="header">Welcome to Products Application</div>
    <img src="./assets/logo.png">
    <router-view/>
    <div id="footer">Created by <a href="https://www.linkedin.com/in/dimitrisvarvaras/">Dimitrios Varvaras</a></div>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#header {
  position: static;
  width: 100%;
  font-size: 1.3em;
  line-height: 100px;
  top: 0px;
  height: 100px;
  background: #f2f2f2;
  margin-bottom: 20px;
}
#footer {
  position: static;
  width: 100%;
  bottom: 0px;
  font-size: 1em;
  height: 100px;
  line-height: 100px;
  background: #f2f2f2;
  margin-bottom: 20px;
}
</style>
