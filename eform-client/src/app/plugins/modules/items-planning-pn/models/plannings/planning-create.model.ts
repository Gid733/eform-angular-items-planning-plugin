import {PlanningItemModel} from './planning-item.model';
import {Moment} from 'moment';

export class PlanningCreateModel {
  name: string;
  description: string;
  repeatEvery: number;
  repeatType: number;
  dayOfWeek: number;
  dayOfMonth: number;
  repeatUntil: string;
  startFrom: string;
  internalRepeatUntil: Moment | null;
  relatedEFormId: number;
  item: PlanningItemModel = new PlanningItemModel();
  eFormSdkFolderId: number;
  eFormSdkFolderName: string;
  tagsIds: number[];
}
