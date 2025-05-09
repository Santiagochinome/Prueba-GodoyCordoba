<template>
  <div class="result-container">
    <div class="result">
      <!-- Imagen de GIF -->
      <div class="gif-container">
        <img :src="gifUrl" alt="Cat GIF" />
        <div class="button-wrapper">
          <button @click="refreshGif">Refrescar GIF</button>
        </div>
      </div>

      <!-- Texto del CatFact -->
      <div class="catfact-container">
        <p>{{ fact }}</p>
      </div>
    </div>
  </div>
</template>

<script>
const API_BASE_URL = "http://localhost:5130";

export default {
  data() {
    return {
      gifUrl: "",
      fact: "",
      wordOffset: 3, 
      isEndOfFact: false,
    };
  },
  created() {
    this.fetchFactAndGif();
  },
  methods: {
    async fetchFactAndGif() {
      try {
        const response = await fetch(`${API_BASE_URL}/api/Gif`);
        if (!response.ok) throw new Error("Error al obtener datos");

        const data = await response.json();
        this.fact = data.fact;
        this.gifUrl = data.gifUrl;
        this.wordOffset = 3;
        this.isEndOfFact = false;
      } catch (error) {
        console.error("Error al obtener fact y gif:", error);
        this.fact = "Error al obtener dato del gato.";
        this.gifUrl = "https://via.placeholder.com/200";
      }
    },

    async refreshGif() {
      const words = this.fact.split(" ");

      if (this.isEndOfFact) {
        this.wordOffset = 3; 
        this.isEndOfFact = false;
        return;
      }

      const nextWords = words.slice(this.wordOffset, this.wordOffset + 3);
      if (nextWords.length < 3) {
        this.isEndOfFact = true; 
        return; 
      }

      const query = nextWords.join(" ");
      const response = await fetch(`${API_BASE_URL}/api/Gif/refresh?fact=${encodeURIComponent(this.fact)}&query=${encodeURIComponent(query)}`);

      if (response.ok) {
        const data = await response.json();
        this.gifUrl = data.gifUrl || "https://via.placeholder.com/200"; 
        this.wordOffset += 3; 
        this.$emit("gifRefreshed", this.fact);
      } else {
        console.error("Error al refrescar el GIF.");
      }
    },
  },
};
</script>

<style scoped>
.result-container {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 20px;
}

.result {
  display: flex;
  align-items: center;
}

.gif-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-right: 20px;
}

.gif-container img {
  width: 200px;
  height: 200px;
  object-fit: cover;
}

.catfact-container {
  max-width: 500px;
  word-wrap: break-word;
}

.button-wrapper {
  margin-top: 10px;
}

button {
  padding: 10px 20px;
  cursor: pointer;
}
</style>
