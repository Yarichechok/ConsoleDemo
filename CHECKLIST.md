# Porting/QA Checklist

## Базове
- [ ] **IL2CPP Release** (без Development/Debugging)
- [ ] **Input System (New)** активний
- [ ] Сцена додана у **Build Profiles → Scene List**
- [ ] `CompanyName/ProductName` заповнені (для правильного шляху сейву)

## UI/UX
- [ ] Меню повністю керується стрілками/WASD + Enter/Space (і з мишою)
- [ ] UIFocus виділяє `StartButton` при старті
- [ ] `QuitButton → MenuController.OnQuit()` прив’язаний
- [ ] Пауза: **Esc → overlay**, **Enter/Space → resume**, **Q → quit**
- [ ] **Safe Area** застосовується (можна симулювати `fallbackPaddingPercent = 0.05`)
- [ ] PauseOverlay рендериться **поверх** Menu (порядок у SafeArea)

## Техніка
- [ ] **0 B GC.Alloc** у `Update()` (PlayerMove) у профайлері
- [ ] TargetFrameRate = 60, VSync = 1 (Boot.cs)
- [ ] Сейв пишеться у `persistentDataPath/save.json`
- [ ] Platform.Services викликається в Boot (видно log у консолі/журналі)
- [ ] Burst AOT (опц.) SSE2+AVX2

## Платформи
- [ ] `Platform.cs` компілюється (умови `#if UNITY_PS5/UNITY_GAMECORE/UNITY_XBOXONE/UNITY_SWITCH`)
- [ ] За потреби — тестова дефініція (`FAKE_PS5`) для демо іншої гілки
- [ ] Нема прямих шляхів/Win-API; лише `persistentDataPath` для запису

## Фінал
- [ ] Build запускається поза редактором, керування/сейв/пауза працюють
- [ ] README оновлений (версія Unity, інструкції з білду/керування)
