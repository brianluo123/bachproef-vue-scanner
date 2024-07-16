<template>
  <StreamBarcodeReader @decode="handleBarcodeReceived" @loaded="onLoaded"></StreamBarcodeReader>
</template>

<script setup>
import { StreamBarcodeReader } from "vue-barcode-reader";
import { defineEmits, defineProps } from 'vue';

const props = defineProps({ onDecode: Function });

const emit = defineEmits(['decode']);

const handleBarcodeReceived = (result) => {
  emit('decode', result)
}
</script>