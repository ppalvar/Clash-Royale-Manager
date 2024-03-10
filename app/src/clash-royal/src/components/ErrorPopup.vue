<template>
    <div class="popup error-popup">
      <div class="popup-icon error-icon">
        <svg
          class="error-svg"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 20 20"
          aria-hidden="true"
        >
          <path
            fill-rule="evenodd"
            d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z"
            clip-rule="evenodd"
          ></path>
        </svg>
      </div>
      <div class="error-message">{{msg}}</div>
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
  
  /* ERROR */
  
  .error-popup {
    background-color: #fef2f2;
    border: solid 1px #f87171;
  }
  .error-icon path {
    fill: #f87171;
  }
  .error-message {
    color: #991b1b;
  }
  
</style>