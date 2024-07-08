<script setup>
import { ref, computed } from 'vue'
import NavMenu from './shared/NavMenu.vue'
import Index from './pages/Index.vue'
import Shipment from './pages/shipments/Shipment.vue'

const routes = {
  '/shipment': Shipment,
  '/': Index,
}

const currentPath = ref(window.location.hash)

window.addEventListener('hashchange', () => {
  currentPath.value = window.location.hash
})

const currentView = computed(() => {
  return routes[currentPath.value.slice(1) || '/']
})
</script>

<template>
  <header>
    <NavMenu />
  </header>
  
  <main>
    <component :is="currentView" />
  </main>
</template>

<style scoped>
header {
  line-height: 1.5;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
