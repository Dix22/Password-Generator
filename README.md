# 🔐 Password Generator Tool

This is a console-based password generator built in C#. It offers two modes:

1. **Classic Mode** – Generate completely random passwords with options for uppercase, lowercase, numbers, and symbols.
2. **Keyword-Based Mode** – Generate passwords based on personal keywords (e.g., name, pet, city), ideal for creating memorable but strong passwords.

---

## ⚙️ Features

- Two generation modes
- Customizable password length
- Option to include/exclude character types
- Multiple password generation
- Outputs saved to `passwords.txt`
- Multi-language support in progress (English / Español)
- Console interface with colored messages

---

## 📂 File Output

All generated passwords are saved in the file:
```
passwords.txt
```

> ⚠️ Note: In Classic Mode, the file path might appear multiple times due to a display bug. This is under review.

---

## 💻 How to Run

1. Clone the repository  
   ```bash
   git clone https://github.com/yourusername/PasswordGenerator.git
   ```

2. Open the solution in Visual Studio

3. Build and run the project

---

## 🧠 Future Improvements

- Fix duplicated file path message in Classic Mode ✅
- Language selector (EN/ES) toggle in menu 🔁
- GUI version using WinForms or WPF 🎨
- Password strength meter 🔒

---

## 🛠 Built With

- C# 7.3
- .NET Framework (Console App)

---

## 🤝 Contributing

Pull requests are welcome! If you have a fix for the display issue or want to help with language support, feel free to contribute.

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

## 📫 Contact

Developed by **Dix22**  
Discord: `__decep`
