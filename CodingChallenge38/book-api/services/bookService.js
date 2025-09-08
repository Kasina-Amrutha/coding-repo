const express = require('express');
const fs = require('fs').promises;
const path = require('path');
const { EventEmitter } = require('events');

const router = express.Router();
const filePath = path.join(__dirname, '../data/books.json');
const bookEvents = new EventEmitter();

// Event Listeners
bookEvents.on('bookAdded', () => console.log('Book Added'));
bookEvents.on('bookUpdated', () => console.log('Book Updated'));
bookEvents.on('bookDeleted', () => console.log('Book Deleted'));

// Utility functions
const readBooks = async () => {
  try {
    const data = await fs.readFile(filePath, 'utf8');
    return JSON.parse(data);
  } catch (err) {
    console.error('Error reading books:', err);
    return [];
  }
};

const writeBooks = async (books) => {
  try {
    await fs.writeFile(filePath, JSON.stringify(books, null, 2));
  } catch (err) {
    console.error('Error writing books:', err);
  }
};

// GET all books
router.get('/', async (req, res) => {
  const books = await readBooks();
  res.json(books);
});

// GET book by ID
router.get('/:id', async (req, res) => {
  const books = await readBooks();
  const book = books.find(b => b.id === parseInt(req.params.id));
  if (!book) return res.status(404).json({ message: 'Book not found' });
  res.json(book);
});

// POST add new book
router.post('/', async (req, res) => {
  const { title, author } = req.body;
  if (!title || !author) {
    return res.status(400).json({ message: 'Title and author are required' });
  }

  const books = await readBooks();
  const newBook = {
    id: books.length ? books[books.length - 1].id + 1 : 1,
    title,
    author
  };

  books.push(newBook);
  await writeBooks(books);
  bookEvents.emit('bookAdded');

  res.status(201).json(newBook);
});

// PUT update book by ID
router.put('/:id', async (req, res) => {
  const { title, author } = req.body;
  const books = await readBooks();
  const bookIndex = books.findIndex(b => b.id === parseInt(req.params.id));

  if (bookIndex === -1) return res.status(404).json({ message: 'Book not found' });

  books[bookIndex] = {
    ...books[bookIndex],
    title: title || books[bookIndex].title,
    author: author || books[bookIndex].author
  };

  await writeBooks(books);
  bookEvents.emit('bookUpdated');

  res.json(books[bookIndex]);
});

// DELETE book by ID
router.delete('/:id', async (req, res) => {
  const books = await readBooks();
  const filteredBooks = books.filter(b => b.id !== parseInt(req.params.id));

  if (books.length === filteredBooks.length)
    return res.status(404).json({ message: 'Book not found' });

  await writeBooks(filteredBooks);
  bookEvents.emit('bookDeleted');

  res.json({ message: 'Book deleted successfully' });
});

module.exports = router;
