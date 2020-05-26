import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatDialogModule, MatSidenavModule, MatIconModule, MatExpansionModule, MatFormFieldModule, MatInputModule, MatRippleModule, MatMenuModule, MatRipple, MatCheckboxModule, MatProgressBarModule, MatCardModule, MatTabsModule} from "@angular/material"
import { DragDropModule } from '@angular/cdk/drag-drop'
const MaterialComponent = [
  MatButtonModule,
  MatDialogModule,
  MatSidenavModule,
  MatIconModule,
  MatExpansionModule,
  MatInputModule,
  MatMenuModule,
  MatRippleModule,
  MatCheckboxModule,
  MatProgressBarModule,
  MatCardModule,
  DragDropModule,
  MatTabsModule
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MaterialComponent
  ],
  exports:[
    MaterialComponent
  ]
})
export class MaterialModule { }
