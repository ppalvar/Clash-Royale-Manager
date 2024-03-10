<template>
    <div class="popup alert-popup">
      <div class="popup-icon alert-icon">
        <svg
          class="alert-svg"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 20 20"
          aria-hidden="true"
        >
          <path
            fill-rule="evenodd"
            d="M8.257 3.099c.765-1.36 2.722-1.36 3.486 0l5.58 9.92c.75 1.334-.213 2.98-1.742 2.98H4.42c-1.53 0-2.493-1.646-1.743-2.98l5.58-9.92zM11 13a1 1 0 11-2 0 1 1 0 012 0zm-1-8a1 1 0 00-1 1v3a1 1 0 002 0V6a1 1 0 00-1-1z"
            clip-rule="evenodd"
          ></path>
        </svg>
      </div>
      <div class="alert-message">{{msg}}</div>
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
  
  /* ALERT */
  .alert-popup {
    background-color: #fefce8;
    border: solid 1px #facc15;
  }
  .alert-icon path {
    fill: #facc15;
  }
  .alert-message {
    color: #ca8a04;
  }
  
</style>