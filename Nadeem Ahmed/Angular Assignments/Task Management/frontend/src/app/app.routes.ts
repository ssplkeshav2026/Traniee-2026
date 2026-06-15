import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';
import { Dashboard } from './pages/dashboard/dashboard';
import { authGuard } from './core/guards/auth.guard';
import { roleGuard } from './core/guards/role-guard';
import { MyTasks } from './pages/my-tasks/my-tasks';
import { CreateTask } from './pages/create-task/create-task';
import { UserList } from './pages/user-list/user-list';
import { TaskList } from './pages/task-list/task-list';
import { TaskDetails } from './pages/task-details/task-details';
import { EditTask } from './pages/edit-task/edit-task';
import { ViewTask } from './pages/view-task/view-task';
import { ViewUser } from './pages/view-user/view-user';
import { EditUser } from './pages/edit-user/edit-user';

export const routes: Routes = [

    {
        path: 'login',
        component: Login
    },
    {
        path: 'register',
        component: Register
    },
    {
        path: 'dashboard',
        component: Dashboard,
        canActivate: [authGuard]
    },
    {
        path: 'my-tasks',
        component: MyTasks,
        canActivate: [authGuard]
    },

    {
        path: 'tasks',
        component: TaskList,
        canActivate: [authGuard, roleGuard],
        data: {
            roles: ['Admin', 'Manager']
        }
    },

    {
        path: 'tasks/:id',
        component: TaskDetails,
        canActivate: [authGuard]
    },

    {
        path: 'tasks/edit/:id',
        component: EditTask,
        canActivate: [authGuard, roleGuard],
        data: {
            roles: ['Admin', 'Manager']
        }
    },

    {
        path: 'create-task',
        component: CreateTask,
        canActivate: [authGuard, roleGuard],
        data: {
            roles: ['Admin', 'Manager']
        }
    },

    {
        path: 'users',
        component: UserList,
        canActivate: [authGuard, roleGuard],
        data: {
            roles: ['Admin']
        }
    },

    {
        path: 'tasks/view/:id',

        component: ViewTask,

        canActivate: [
            authGuard,
            roleGuard
        ],

        data: {
            roles: [
                'Admin',
                'Manager'
            ]
        }
    },

    {
        path: 'users/view/:id',
        component: ViewUser,
        canActivate: [authGuard, roleGuard],
        data: {
            roles: ['Admin']
        }
    },

    {
        path: 'users/edit/:id',
        component: EditUser,
        canActivate: [authGuard, roleGuard],
        data: {
            roles: ['Admin']
        }
    }
];
