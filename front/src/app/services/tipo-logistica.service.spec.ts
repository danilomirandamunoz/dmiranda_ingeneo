import { TestBed } from '@angular/core/testing';

import { TipoLogisticaService } from './tipo-logistica.service';

describe('TipoLogisticaService', () => {
  let service: TipoLogisticaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TipoLogisticaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
