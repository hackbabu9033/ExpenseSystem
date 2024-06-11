import React, { useState, useEffect } from 'react';

function ExpenseForm({ onCreate, onUpdate, editingExpense }) {
  const [title, setTitle] = useState('');
  const [amount, setAmount] = useState('');
  const [date, setDate] = useState('');
  const [category, setCategory] = useState('');

  // 預設分類選項
  const categories = ['Food', 'Clothing', 'Housing', 'Transportation'];
  const defaultCategory = categories[0];

  useEffect(() => {
    if (editingExpense) {
      setTitle(editingExpense.title);
      setAmount(editingExpense.amount);
      setDate(editingExpense.date.split('T')[0]);
      setCategory(editingExpense.category);
    } else {
      setTitle('');
      setAmount('');
      setDate('');
      setCategory(defaultCategory);
    }
  }, [editingExpense]);

  const handleSubmit = (e) => {
    e.preventDefault();
    const expense = { title, amount, date, category };
    if (editingExpense) {
      onUpdate(editingExpense.id, expense);
    } else {
      onCreate(expense);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="mb-4">
      <div className="form-group">
        <label>Title</label>
        <input
          type="text"
          className="form-control"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
        />
      </div>
      <div className="form-group">
        <label>Amount</label>
        <input
          type="number"
          className="form-control"
          value={amount}
          onChange={(e) => setAmount(e.target.value)}
        />
      </div>
      <div className="form-group">
        <label>Date</label>
        <input
          type="date"
          className="form-control"
          value={date}
          onChange={(e) => setDate(e.target.value)}
        />
      </div>
      <div className="form-group">
        <label>Category</label>
        <select
          className="form-control"
          value={category}
          onChange={(e) => setCategory(e.target.value)}
        >
          {categories.map((cat) => (
            <option key={cat} value={cat}>
              {cat}
            </option>
          ))}
        </select>
      </div>
      <button type="submit" className="btn btn-primary">
        {editingExpense ? 'Update' : 'Create'}
      </button>
    </form>
  );
}

export default ExpenseForm;