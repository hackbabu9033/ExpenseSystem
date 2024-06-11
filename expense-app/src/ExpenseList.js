import React from 'react';

function ExpenseList({ expenses, onEdit, onDelete }) {
  return (
    <table className="table">
      <thead>
        <tr>
          <th>Title</th>
          <th>Amount</th>
          <th>Date</th>
          <th>Category</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {expenses.map((expense) => (
          <tr key={expense.id}>
            <td>{expense.title}</td>
            <td>{expense.amount}</td>
            <td>{expense.date}</td>
            <td>{expense.category}</td>
            <td>
              <button
                className="btn btn-primary mr-2"
                onClick={() => onEdit(expense)}
              >
                Edit
              </button>
              <button
                className="btn btn-danger"
                onClick={() => onDelete(expense.id)}
              >
                Delete
              </button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default ExpenseList;