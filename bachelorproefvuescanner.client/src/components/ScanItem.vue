<template>
  <tr>
    <td>{{ props.scan.barcode }}</td>
    <td>{{ props.scan.destination }}</td>
    <td>{{ props.scan.zone }}</td>
  </tr>
</template>

<script setup lang="ts">
import Scan from '@/models/Scan';

const props = defineProps<{ scan: Scan; }>();
</script>