import React, { useState, useEffect } from 'react';
import ExpenseForm from './ExpenseForm';
import ExpenseList from './ExpenseList';
import './App.css';

const API_BASE_URL = 'https://localhost:44313/api/expenses';

function App() {
  const [expenses, setExpenses] = useState([]);
  const [editingExpense, setEditingExpense] = useState(null);

  const fetchExpenses = async () => {
    try {
      const response = await fetch(API_BASE_URL);
      const data = await response.json();
      setExpenses(data);
    } catch (error) {
      console.error('Failed to fetch expenses:', error);
    }
  };

  useEffect(() => {
    fetchExpenses();
  }, []);

  const handleCreate = async (expense) => {
    try {
      const response = await fetch(API_BASE_URL, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(expense),
      });
      if (response.ok) {
        fetchExpenses();
      }
    } catch (error) {
      console.error('Failed to create expense:', error);
    }
  };

  const handleUpdate = async (id, updatedExpense) => {
    try {
      const response = await fetch(`${API_BASE_URL}/${id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedExpense),
      });
      if (response.ok) {
        fetchExpenses();
        setEditingExpense(null); // Reset editing expense
      }
    } catch (error) {
      console.error('Failed to update expense:', error);
    }
  };

  const handleDelete = async (id) => {
    try {
      const response = await fetch(`${API_BASE_URL}/${id}`, {
        method: 'DELETE',
      });
      if (response.ok) {
        fetchExpenses();
      }
    } catch (error) {
      console.error('Failed to delete expense:', error);
    }
  };

  return (
    <div className="container">
      <h1>Expense Tracker</h1>
      <ExpenseForm
        onCreate={handleCreate}
        onUpdate={handleUpdate}
        editingExpense={editingExpense}
      />
      <ExpenseList
        expenses={expenses}
        onEdit={setEditingExpense}
        onDelete={handleDelete}
      />
    </div>
  );
}

export default App;
