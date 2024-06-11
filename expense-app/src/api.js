const API_BASE_URL = 'https://localhost:44313/api/expenses';

export async function fetchExpenses() {
  const response = await fetch(API_BASE_URL);
  return await response.json();
}

export async function createExpense(expense) {
  console.log(expense);
  const response = await fetch(API_BASE_URL, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(expense)
  });
  return await response.json();
}

export async function updateExpense(id, expense) {
  const response = await fetch(`${API_BASE_URL}/${id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(expense)
  });
  return await response.json();
}

export async function deleteExpense(id) {
  await fetch(`${API_BASE_URL}/${id}`, {
    method: 'DELETE'
  });
}