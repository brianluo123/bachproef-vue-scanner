<template>
  <div class="sidebar">
    <a href="#/" class="home">BachelorproefVueScanner</a>
    <a href="#/">Home</a>
    <a href="#/shipment">Shipment</a>
  </div>
</template>

<style scoped>
.sidebar {
    width: 300px;
    height: 100%;
    background-color: #666;
    top: 0;
    left: 0;
}

.sidebar a {
  display: block;
  color: white;
  text-decoration: none;
  padding: 15px;
}

.sidebar a:hover {
  background-color: #575757;
}

.home {
  font-size: large;
  background-color: #333;
}

</style>