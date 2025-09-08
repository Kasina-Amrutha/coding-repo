const express = require('express');
const bookRoutes = require('./services/bookService');

const app = express();
const PORT = 3000;

app.use(express.json());

app.get('/', (req, res) => {
  res.json({ message: "Welcome to Book Management API" });
});

// Book Routes
app.use('/books', bookRoutes);

app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
