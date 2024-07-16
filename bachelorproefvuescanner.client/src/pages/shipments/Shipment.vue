<template>
    <h1>Shipment</h1>

    <form @submit.prevent="createScanAsync">

        <!--Barcode-->
        <div class="form-group mb-2">
            <label>Scan a barcode</label>
            <div class="input-group">
                <input type="text" v-model="scan.barcode" class="form-control" />
                <div class="input-group-append">
                    <button class="btn btn-outline-secondary" type="button" @click="openModal">Scan</button>
                </div>
            </div>
        </div>

        <!--Destination-->
        <div class="form-group mb-2">
            <label>Select a destination</label>
            <select class="form-control" v-model="scan.destination">
                <option value="" disabled>--select--</option>
                <option v-for="destination in destinations" :key="destination" :value="destination">
                    {{ destination }}
                </option>
            </select>
        </div>

        <!--Zone-->
        <div class="form-group mb-2">
            <label>Choose a zone</label>
            <input type="text" v-model="scan.zone"  class="form-control" />
        </div>

        <div v-if="scanTime != 0">
            <p>Time to scan barcode: {{ scanTime }} milliseconds</p>
        </div>

        <!--Submit button--> 
        <div class="buttons d-flex justify-content-end mt-3">
            <button class="btn btn-secondary" type="submit">OK</button>
        </div>
    </form>

    <h5>Scanned barcodes</h5>

    <p v-if="scans == null">Loading...</p>

    <p v-else-if="scans.length == 0">No scans yet</p>

    <table v-else class="table table-striped">
      <thead>
          <tr>
              <th scope="col">Barcode</th>
              <th scope="col">Destination</th>
              <th scope="col">Zone</th>
          </tr>
      </thead>
      <tbody>
          <ScanItem v-for="scan in scans" :scan="scan" />
      </tbody>
    </table>

    <div v-if="showModal" class="modal fade show" style="display: block;" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Scan a barcode</h5>
                    <button type="button" class="close d-flex justify-content-center" @click="closeModal">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <Suspense>
                        <Scanner @decode="receivedBarcodeText" />
                    </Suspense>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, onMounted, defineAsyncComponent } from 'vue';
import Scan from '@/models/Scan';
import ScanItem from '@/components/ScanItem.vue';
const Scanner = defineAsyncComponent(() => import('@/components/Scanner.vue'));

const scans = ref(null)
const scan = ref(new Scan())
const destinations = ref(["Gent", "Antwerpen", "Brussel"])
const showModal = ref(false)
const startTime = ref()
const endTime = ref()
const scanTime = ref(0)

onMounted(() => {
  getScansAsync()
})

const getScansAsync = async () => {
  await fetch('api/scans')
    .then(r => r.json())
    .then(json => {
      console.log(json)
      scans.value = json
    })
}

const createScanAsync = async () => {
  await fetch('/api/scans', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(scan.value)
  });

  console.log(scan.value);

  scan.value = new Scan()
  scanTime.value = 0
  await getScansAsync()
}

const receivedBarcodeText = (result) => {
  endTime.value = new Date()
  scanTime.value = endTime.value - startTime.value
  scan.value.barcode = result
  closeModal()
}

const openModal = () => {
  showModal.value = true;
  startTime.value = new Date();
}

const closeModal = () => {
  showModal.value = false;
}
</script>

<style scoped>
.modal-body {
    max-width: fit-dialog;
    margin-left: auto;
    margin-right: auto;
}

h1 {
  margin-top: 10px;
}

.modal-header {
    display: flex;
    align-items: center;
}
    
.modal-header .close {
    margin-left: auto;
}
</style>
