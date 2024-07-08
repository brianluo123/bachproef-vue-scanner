<template>
  <div class="sidebar">
    <a href="#/">Home</a>
    <a href="#/shipment">Shipment</a>
  </div>
</template>

<style scoped>
.sidebar {
    width: 250px;
    height: 100%;
    background-color: #333;
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

</style>