<template>
  <div class="sidebar">
    <div class="home d-flex align-items-center">
      <p>BachelorproefVueScanner</p>
      <div @click="toggleMenu" class="d-flex justify-content-center align-items-center" style="width: 100%;">
        <div>
          <div class="menu"></div>
          <div class="menu"></div>
          <div class="menu"></div>
        </div>
      </div>
    </div>
    <div v-if="showMenu">
      <a href="#/" class="item">Home</a>
      <a href="#/shipment" class="item">Shipment</a>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';

const showMenu = ref(true)

const toggleMenu = () => {
  showMenu.value = !showMenu.value
}

</script>

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

p {
  display: block;
  color: white;
  text-decoration: none;
  padding: 15px;
  margin-bottom: 5px;
}

.sidebar a:hover {
  background-color: #575757;
}

.home {
  font-size: large;
  background-color: #333;
}

.menu {
  width: 22px;
  height: 3px;
  background-color: black;
  margin: 6px 0;
  background-color: white;
}
</style>