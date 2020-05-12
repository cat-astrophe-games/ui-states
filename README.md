# Demo of using and designing user interface states

Demo how to design a game with multiple UI states,
- keeping each UI state in a separate prefab,
- and handling each UI state by a pair of classes `ViewXxx` and `StateXxx`

## UI states in prefabs

In this example, we have 3 UI states:

- main menu (only UI, opaque)

- play (UI + 3D world underneath)

- options (only UI, may be transparent, with the intention to see "game" underneath)

The goal is to split your UI design into multiple files.

Details:

- The main scene should be as simple as possible. Ideally, just a single GameObject that runs a single script like `GameManager`. Additional "central" stuff is OK too (like Unity canvas and event handler).

- Avoid a common problem when editing non-trivial Unity projects: it is too easy to create a main scene with lots of stuff. Editing such large scene is risky (it's easy to break something you didn't even think you could break, since the scene contains too much stuff). And it's prone to version-control conflicts.

- Split everything you can (UI and not UI) into prefabs. This allows to easily "scale" the approach: you can place complicated stuff inside each prefab, you can create lots of UI states etc. without causing headaches.

- At the top of each prefab, place a MonoBehaviour that contains references to things inside. Like `ViewMainMenu.cs`, `ViewOptions.cs` etc.

- This way, the code can load a prefab like `MainMenu.prefab`, and assume it contains a script like `ViewMainMenu.cs` with public fields referencing stuff that can be handled from code.

- This way the UI designer can completely freely move stuff around in prefabs. (S)he only has to care to attach stuff in `ViewMainMenu.cs`. The `ViewMainMenu.cs` becomes a "contract" between UI designer and programmer: what should be exposed and handled from code.

There are many variations of this approach, I'm sure. Treat this only as an example.

One idea for enhancement: It may be useful to tweak background handling:

- place the `Background` GameObject in the scene, too,

- and then design all UI states as transparent,

- and from code, toggle the `Background` visibility when entering/exiting proper state.

## Usage from code

Simple UI state management in C#:

- each UI state has a `ViewXxx` (descendant of `MonoBehaviour`), a "contract" between UI designer and programmer.

- each UI state has a `StateXxx` (descendant of `UiState`, not `MonoBehaviour`) that contains the logic of this state. If you like MVC terminology, this is the "controller" code.

- singleton `GameManager.Instance` manages the states, calling their `Show` / `Hide` methods, when you do `SetState`, `PushState`, `PopState`.

- The code is just a starting point, you can probably enhance it as needed. E.g. implement `UiState.Pause`, `UiState.Resume` etc.
