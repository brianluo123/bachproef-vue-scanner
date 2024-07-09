export default class Scan {
    constructor(barcode = '', zone = '', destination = '') {
      this.barcode = barcode;
      this.destination = destination;
      this.zone = zone;
    }
  }