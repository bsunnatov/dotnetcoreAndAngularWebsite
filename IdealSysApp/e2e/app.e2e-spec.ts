import { IdealsysNGPage } from './app.po';

describe('idealsys-ng App', () => {
  let page: IdealsysNGPage;

  beforeEach(() => {
    page = new IdealsysNGPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
