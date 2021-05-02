import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TempConverterComponent } from './components/temp-converter/temp-converter.component';

const routes: Routes = [
  {
    path: '',
    component: TempConverterComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }