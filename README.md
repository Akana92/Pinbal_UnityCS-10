# Pinball Game

## Overview

This is a simple pinball game built using Unity's 3D primitives. The project showcases various Unity physics and interaction systems. The game features automatic ball launch, player-controlled flippers, bumpers, rotating objects, and linear-moving objects that affect the ball's movement. The goal is to keep the ball in play for as long as possible.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
  - [1. Automatic Ball Launch](#1-automatic-ball-launch)
  - [2. Flippers](#2-flippers)
  - [3. Bumpers](#3-bumpers)
  - [4. Rotating Objects](#4-rotating-objects)
  - [5. Linear Moving Objects](#5-linear-moving-objects)

## Features

### 1. Automatic Ball Launch

- **Objective**: Automatically launch the ball at the beginning of the game.
- **Functionality**: The ball is launched into the game automatically without requiring player input.
- **Key Components**:
  - `BallLauncher.cs`: This script applies an initial force to the ball, propelling it into the game field.

### 2. Flippers

- **Objective**: Allow the player to control flippers to keep the ball in play.
- **Functionality**:
  - The player controls two flippers located at the bottom of the game field using the left and right arrow keys.
  - The flippers rotate when pressed to hit the ball.
- **Key Components**:
  - `FlipperControl.cs`: This script allows the player to control each flipper. The left flipper is controlled with the left arrow key, and the right flipper is controlled with the right arrow key.
  - **Hinge Joint**: The flippers use Unity’s hinge joints to rotate and hit the ball.

### 3. Bumpers

- **Objective**: Add dynamic interactions with the ball.
- **Functionality**:
  - The bumpers are static objects placed in the game field to bounce the ball in random directions when hit.
- **Key Components**:
  - `Bumper.cs`: This script handles the physics interactions between the bumpers and the ball, applying force to the ball on impact.

### 4. Rotating Objects

- **Objective**: Provide additional challenges by rotating objects in the playfield.
- **Functionality**:
  - Rotating objects continuously spin around a fixed axis, affecting the ball’s movement when it comes into contact.
- **Key Components**:
  - `RotatingObject.cs`: This script rotates objects around a fixed axis at a set speed. The object’s rotation adds randomness to the ball's trajectory.

### 5. Linear Moving Objects

- **Objective**: Add linear-moving obstacles that challenge the ball’s path.
- **Functionality**:
  - Linear moving objects move back and forth between two points, creating dynamic obstacles for the ball.
- **Key Components**:
  - `MovingObject.cs`: This script moves objects back and forth along a set axis, creating movement that the ball can interact with.

# Игра в Пинбол

## Обзор

Это простая игра в пинбол, созданная с использованием 3D-примитивов Unity. Проект демонстрирует различные физические взаимодействия и системы Unity. Игра включает автоматический запуск шарика, управляемые игроком флипперы, бамперы, вращающиеся объекты и линейно двигающиеся объекты, которые влияют на движение шарика. Цель игры — удерживать шарик в игре как можно дольше.

## Оглавление

- [Обзор](#обзор)
- [Функции](#функции)
  - [1. Автоматический запуск шарика](#1-автоматический-запуск-шарика)
  - [2. Флипперы](#2-флипперы)
  - [3. Бамперы](#3-бамперы)
  - [4. Вращающиеся объекты](#4-вращающиеся-объекты)
  - [5. Линейно двигающиеся объекты](#5-линейно-двигающиеся-объекты)

## Функции

### 1. Автоматический запуск шарика

- **Цель**: Автоматический запуск шарика в начале игры.
- **Функциональность**: Шарик автоматически запускается в игру без участия игрока.
- **Основные компоненты**:
  - `BallLauncher.cs`: Этот скрипт применяет начальную силу к шарику, чтобы запустить его в игровое поле.

### 2. Флипперы

- **Цель**: Дать игроку возможность управлять флипперами для удержания шарика в игре.
- **Функциональность**:
  - Игрок управляет двумя флипперами, расположенными в нижней части игрового поля, с помощью клавиш влево и вправо.
  - Флипперы вращаются при нажатии клавиш, чтобы отбить шарик.
- **Основные компоненты**:
  - `FlipperControl.cs`: Этот скрипт позволяет игроку управлять каждым флиппером. Левый флиппер управляется с помощью клавиши влево, а правый — с помощью клавиши вправо.
  - **Hinge Joint**: Флипперы используют шарниры Unity для вращения и удара по шарику.

### 3. Бамперы

- **Цель**: Добавить динамическое взаимодействие с шариком.
- **Функциональность**:
  - Бамперы — это статичные объекты, расположенные на игровом поле, которые отскакивают шарик в случайных направлениях при ударе.
- **Основные компоненты**:
  - `Bumper.cs`: Этот скрипт обрабатывает физические взаимодействия между бамперами и шариком, применяя силу к шарику при столкновении.

### 4. Вращающиеся объекты

- **Цель**: Создать дополнительные препятствия в игровом поле с вращающимися объектами.
- **Функциональность**:
  - Вращающиеся объекты непрерывно крутятся вокруг фиксированной оси, изменяя траекторию движения шарика при столкновении.
- **Основные компоненты**:
  - `RotatingObject.cs`: Этот скрипт вращает объекты вокруг фиксированной оси с заданной скоростью. Вращение добавляет случайность в траекторию шарика.

### 5. Линейно двигающиеся объекты

- **Цель**: Добавить линейно двигающиеся препятствия, усложняющие путь шарика.
- **Функциональность**:
  - Линейно двигающиеся объекты перемещаются вперед и назад между двумя точками, создавая динамические препятствия для шарика.
- **Основные компоненты**:
  - `MovingObject.cs`: Этот скрипт двигает объекты вперед и назад вдоль заданной оси, создавая движение, с которым может взаимодействовать шарик.
