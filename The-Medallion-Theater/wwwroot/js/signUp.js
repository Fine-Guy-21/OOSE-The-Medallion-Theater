// Get form elements
const form = document.querySelector('.sign-up-form');
const firstNameInput = document.getElementById('fname');
const lastNameInput = document.getElementById('lname');
const addressInput = document.getElementById('address');
const cityInput = document.getElementById('city');
const stateInput = document.getElementById('state');
const zipInput = document.getElementById('zip');
const phoneInput = document.getElementById('phoneNo');
const emailInput = document.getElementById('email');
const passwordInput = document.getElementById('password');
const confirmPasswordInput = document.getElementById('confirm-password');
const privacyPolicyCheckbox = document.getElementById('privacy-policy');

// Event listener for form submission
form.addEventListener('submit', function (event) {
  event.preventDefault(); // Prevent form submission

  // Validate form inputs
  const errors = [];
  if (firstNameInput.value.trim() === '') {
    errors.push('Please enter your first name.');
  }
  if (lastNameInput.value.trim() === '') {
    errors.push('Please enter your last name.');
  }
  if (addressInput.value.trim() === '') {
    errors.push('Please enter your street address.');
  }
  if (cityInput.value.trim() === '') {
    errors.push('Please enter your city.');
  }
  if (stateInput.value.trim() === '') {
    errors.push('Please enter your state.');
  }
  if (zipInput.value.trim() === '') {
    errors.push('Please enter your ZIP code.');
  }
  if (phoneInput.value.trim() === '') {
    errors.push('Please enter your phone number.');
  }
  if (emailInput.value.trim() === '') {
    errors.push('Please enter your email address.');
  }
  if (passwordInput.value.trim() === '') {
    errors.push('Please enter a password.');
  }
  if (confirmPasswordInput.value.trim() === '') {
    errors.push('Please confirm your password.');
  }
  if (passwordInput.value !== confirmPasswordInput.value) {
    errors.push('Passwords do not match.');
  }
  if (!privacyPolicyCheckbox.checked) {
    errors.push('Please accept the terms and privacy policy.');
  }

  // Display errors or submit the form
  if (errors.length > 0) {
    displayErrors(errors);
  } else {
    form.submit(); // Submit the form
  }
});

// Function to display errors
function displayErrors(errors) {
  const errorContainer = document.getElementById('error-container');
  errorContainer.innerHTML = ''; // Clear previous errors

  errors.forEach(function (error) {
    const errorElement = document.createElement('p');
    errorElement.textContent = error;
    errorContainer.appendChild(errorElement);
  });
}