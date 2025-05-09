<template>
  <div class="history-container">
    <h2>Historial de Búsquedas</h2>
    <table>
      <thead>
        <tr>
          <th>Fecha</th>
          <th>Cat Fact</th>
          <th>Query</th>
          <th>GIF</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in history" :key="index">
          <td>{{ new Date(item.timestamp).toLocaleString() }}</td>
          <td>{{ item.catFact }}</td>
          <td>{{ item.query }}</td>
          <td><a :href="item.gifUrl" target="_blank">Ver GIF</a></td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  data() {
    return {
      history: [],
    };
  },
  created() {
    this.loadHistory();
  },
  methods: {
    async loadHistory() {
      try {
        const response = await fetch("http://localhost:5130/api/History");
        if (response.ok) {
          this.history = await response.json();
        } else {
          console.error("No se pudo obtener el historial");
        }
      } catch (error) {
        console.error("Error al obtener historial:", error);
      }
    },
  },
};
</script>

<style scoped>
.history-container {
  padding: 20px;
}

table {
  width: 100%;
  border-collapse: collapse;
}

th,
td {
  padding: 10px;
  border: 1px solid #ccc;
  text-align: left;
}

th {
  background-color: #f5f5f5;
}
</style>
