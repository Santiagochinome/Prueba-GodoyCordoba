<template>
  <div>
    <!-- Pestañas -->
    <div class="tabs">
      <button @click="activeTab = 1" :class="{ active: activeTab === 1 }">Resultado Actual</button>
      <button @click="activeTab = 2" :class="{ active: activeTab === 2 }">Historial</button>
    </div>

    <!-- Contenido de la pestaña -->
    <div v-if="activeTab === 1">
      <CurrentResult />
    </div>

    <div v-if="activeTab === 2">
      <SearchHistory />
    </div>
  </div>
</template>

<script>
import CurrentResult from './CurrentResult.vue';
import SearchHistory from './SearchHistory.vue'; // 👈 Importas el componente

export default {
  components: {
    CurrentResult,
    SearchHistory, // 👈 Lo registras aquí
  },
  data() {
    return {
      activeTab: 1, // Pestaña activa por defecto
    };
  },
};
</script>

<style scoped>
.tabs {
  display: flex;
  justify-content: center;
  margin-bottom: 20px;
}

button {
  padding: 10px 20px;
  margin: 0 10px;
  cursor: pointer;
}

button.active {
  background-color: #007bff;
  color: white;
}

button:hover {
  background-color: #0056b3;
}
</style>
