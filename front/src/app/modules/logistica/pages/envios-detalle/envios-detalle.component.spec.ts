import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnviosDetalleComponent } from './envios-detalle.component';

describe('EnviosDetalleComponent', () => {
  let component: EnviosDetalleComponent;
  let fixture: ComponentFixture<EnviosDetalleComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EnviosDetalleComponent]
    });
    fixture = TestBed.createComponent(EnviosDetalleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
