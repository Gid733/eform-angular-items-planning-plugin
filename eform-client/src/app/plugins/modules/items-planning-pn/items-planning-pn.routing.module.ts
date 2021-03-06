import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AdminGuard, AuthGuard, PermissionGuard} from 'src/app/common/guards';
import {ItemsPlanningPnLayoutComponent} from './layouts';
import {
  PlanningsPageComponent,
  ItemsPlanningSettingsComponent,
  ReportContainerComponent,
  PlanningCasePageComponent,
  PlanningEditComponent, PlanningCreateComponent
} from './components';
import {ItemsPlanningPnClaims} from './enums';

export const routes: Routes = [
  {
    path: '',
    component: ItemsPlanningPnLayoutComponent,
    canActivate: [PermissionGuard],
    data: {requiredPermission: ItemsPlanningPnClaims.accessItemsPlanningPlugin},
    children: [
      {
        path: 'plannings',
        canActivate: [AuthGuard],
        component: PlanningsPageComponent
      },
      {
        path: 'plannings/edit/:id',
        canActivate: [AuthGuard],
        component: PlanningEditComponent
      },
      {
        path: 'plannings/create',
        canActivate: [AuthGuard],
        component: PlanningCreateComponent
      },
      {
        path: 'planning-cases/:id',
        canActivate: [AuthGuard],
        component: PlanningCasePageComponent
      },
      {
        path: 'settings',
        canActivate: [AdminGuard],
        component: ItemsPlanningSettingsComponent
      },
      {
        path: 'reports',
        canActivate: [AdminGuard],
        component: ReportContainerComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemsPlanningPnRouting { }
