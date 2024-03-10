<template>
    <div class="popup info-popup">
      <div class="popup-icon info-icon">
        <svg
          aria-hidden="true"
          viewBox="0 0 20 20"
          xmlns="http://www.w3.org/2000/svg"
          class="info-svg"
        >
          <path
            clip-rule="evenodd"
            d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7-4a1 1 0 11-2 0 1 1 0 012 0zM9 9a1 1 0 000 2v3a1 1 0 001 1h1a1 1 0 100-2v-3a1 1 0 00-1-1H9z"
            fill-rule="evenodd"
          ></path>
        </svg>
      </div>
      <div class="info-message">{{msg}}</div>
      <div class="popup-icon close-icon">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 20 20"
          class="close-svg"
        >
          <path
            d="m15.8333 5.34166-1.175-1.175-4.6583 4.65834-4.65833-4.65834-1.175 1.175 4.65833 4.65834-4.65833 4.6583 1.175 1.175 4.65833-4.6583 4.6583 4.6583 1.175-1.175-4.6583-4.6583z"
            class="close-path"
          ></path>
        </svg>
      </div>
    </div>
</template>

<script>
export default{
    props: {
        msg: {
            type: String,
            default: "Error!!!"
        }
    }
}
</script>

<style scoped>
  /* COMMON STYLES*/
  .popup {
    margin: 10px;
    box-shadow: 4px 4px 10px -10px rgba(0, 0, 0, 1);
    width: 90%;
    justify-content: space-around;
    align-items: center;
    display: flex;
    border-radius: 4px;
    padding: 5px 0;
    font-weight: 300;
  }
  .popup svg {
    width: 1.25rem;
    height: 1.25rem;
  }
  .popup-icon svg {
    margin: 5px;
    display: flex;
    align-items: center;
  }
  .close-icon {
    margin-left: auto;
  }
  .close-svg {
    cursor: pointer;
  }
  .close-path {
    fill: grey;
  }
  
  /* INFO */
  
  .info-popup {
    background-color: #eff6ff;
    border: solid 1px #1d4ed8;
  }
  .info-icon path {
    fill: #1d4ed8;
  }
  .info-message {
    color: #1d4ed8;
  }
  
  </style>