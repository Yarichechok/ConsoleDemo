# ConsoleDemo (Unity 6 LTS, IL2CPP)

Маленький демо-проєкт під “консольний” пайплайн: 60 FPS, навігація з або без миші, пауза/оверлей, сейв, **Safe Area**, платформена абстракція `#if UNITY_PS5/XBOX/SWITCH`, збірка **IL2CPP**.

---

## Як відкрити проєкт і сцену

1. Відкрий через **Unity Hub** → *Add project from disk* → вибери корінь репозиторію (де є `Assets/`, `Packages/`, `ProjectSettings/`).
2. У **Project**: відкрити **`Assets/Scenes/SampleScene.unity`** (двічі кліком).
   - Якщо в Hierarchy порожня `Untitled` — це дефолтна сцена редактора. Просто відкрий `Assets/Scenes/SampleScene.unity`.
3. (Опц.) **File → Build Settings…** → **Add Open Scenes**, щоб сцена точно потрапила в білд.

---

## Збірка

**Вимоги:** Unity 6.0 LTS (Editor), Windows x86_64.

**Player Settings:**
- Scripting Backend: **IL2CPP**
- Api Compatibility: **.NET Standard 2.1**
- Active Input Handling: **Input System (New)**
- Target: **x86_64**
- (Опц.) **Burst AOT** → Target 64Bit CPU: **SSE2, AVX2**

**Як збирати (Windows):**
1. `File → Build Profiles… → Windows (Active)`
2. `Open Scene List → Add Open Scenes` (щоб `SampleScene` була з галочкою)
3. Зняти **Development Build** та **Script Debugging**
4. `Build` → папка, напр.: `Builds/Windows/`
5. Запустити `ConsoleDemo.exe`

---

## Керування

**Меню:**
- Стрілки / WASD — навігація
- **Enter/Space** — Confirm
- **Esc** — Back / Pause

**У грі:**
- **WASD / Стрілки** — рух
- **Esc** — Pause (оверлей)
- **Enter/Space** на паузі — Resume
- **Q** на паузі — Quit

**Геймпад:**
- Працює (новий Input System). Якщо контролер від’єднати — з’являється оверлей **“Paused — Controller disconnected”**.

---

## Що зроблено (“console-ready on PC”)

- **UI без миші**: `EventSystem + Input System UI`, автофокус на першій кнопці (`UIFocus`)
- **Меню** Start/Quit + **PauseOverlay** (resume/quit, повідомлення про контролер)
- **Safe Area** для TV/overscan: `SafeAreaApplier` + контейнер `SafeArea`
- **Сейв** у `Application.persistentDataPath/save.json` (тригер по Space/Enter)
- **0 GC.Alloc у Update()** в рухові гравця (`PlayerMove`)
- **IL2CPP** Release білд (Windows x86_64)
- **Платформена абстракція**: `Platform.Services` з `#if UNITY_PS5 / UNITY_GAMECORE / UNITY_XBOXONE / UNITY_SWITCH`
- **Boot**: 60 FPS, VSync = 1, курсор приховано/locked, стартове повідомлення через `Platform.Services`

---

## Де лежить сейв

- Пишеться у `Application.persistentDataPath/save.json`.
- Windows: `C:\Users\<ІМ’Я_КОРИСТУВАЧА>\AppData\LocalLow\<CompanyName>\<ProductName>\save.json`.

---

## Скріншоти

Меню:
![Menu](Images/Menu.png "Головне меню (Start/Quit)")

Пауза/оверлей:
![Pause](Images/Pause.png "Пауза, повідомлення про ненаявність(в данному випадку контролера) і можливість вийти з гри")


---

## Структура

Assets/
Scripts/
Boot.cs
PlayerMove.cs
SaveSystem.cs
UI/
UIFocus.cs
MenuController.cs
PauseManager.cs
SafeAreaApplier.cs
Platform/
Platform.cs